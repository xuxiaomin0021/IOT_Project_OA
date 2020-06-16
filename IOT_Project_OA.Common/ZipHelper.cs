using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    /// <summary>
    /// 文件压缩和解压缩
    /// </summary>
  public  class ZipHelper
    {

        #region 文件压缩
        /// <summary>
        /// 文件压缩
        /// </summary>
        /// <param name="path">需要压缩的文件路径</param>
        /// <param name="flag">判断压缩文件还是文件夹如果是0代表压缩文件夹，1代表压缩文件</param>
        public void ZipCompress(string path,int flag)
        {
        
            //截取文件夹路径
            string pathFolders = path.Substring(0, path.LastIndexOf("\\"));
            //路径+文件名称
            string createZipFilePath = pathFolders + path.Substring(path.LastIndexOf("\\"))+".rar";

            createZipFilePath = createZipFilePath.Replace(".xls", "");
            using (ZipFile zip = ZipFile.Create(createZipFilePath))
            {
                zip.BeginUpdate();
                //压缩文件夹
                if (flag == 0)
                {
                    ZipFolders(path, zip, path.LastIndexOf('\\') + 1);//E：\\
                }
                //普通压缩
                else {
                    //获取到的是文件路径和文件名称不包含后缀
                    string filePath = createZipFilePath.Substring(0, createZipFilePath.IndexOf("."));
                    filePath = filePath.Substring(filePath.LastIndexOf("\\"));
                    zip.Add(path, filePath+".xls");
                }
                zip.CommitUpdate();
            }
        }
        //压缩文件夹下的所有文件及文件夹
        private void ZipFolders(string path, ZipFile zip, int charLength)
        {
            string[] strAry = null;

            strAry = Directory.GetFiles(path);//压缩文件夹下的所有文件不好含文件下的文件夹
                                              /*****************************初始化时获取当前路径下的所有的文件***************************************************/
            for (int i = 0; i < strAry.Length; i++)
            {
                string parent = path.Substring(charLength);//截取出来时没有盘符
                //第一个参数文件的物理路径，第二个参数是虚拟路径（压缩包中的路径）不要盘符的路径。test\就是文件夹\文件名称
                zip.Add(strAry[i], parent + "\\" + new FileInfo(strAry[i]).Name);
            }
            /*****************************初始化时获取当前路径下的当前的文件夹***************************************************/
            string[] strDirectories = Directory.GetDirectories(path);
            for (int i = 0; i < strDirectories.Length; i++)
            {
                ZipFolders(strDirectories[i], zip, charLength);//递归
            }
        }
        #endregion
        #region 解压缩
        public void ZipUnCompress(string rarPath,string extract)
        {
            //1.压缩包的路径及压缩包的名称 
            //2.解压缩的路径及名称
            using (ZipInputStream zis = new ZipInputStream(File.OpenRead(rarPath)))//首先读取文件流（内存中）
            {
                ZipEntry entry = null;
                while ((entry = zis.GetNextEntry()) != null)//提供了一个迭代的方法，每循环一次获取下一条数据 返回entry
                {
                    string temp = entry.Name;//06/tt/tt/xx.txt//Name时一个虚拟的路径
                    //这一句是拼接物理路径\虚拟路径到文件夹 E：\\test1\虚拟路径的文件夹
                    //用于创建文件夹
                    string directorName = extract + "\\" + Path.GetDirectoryName(temp);
                    string fileName = extract + "\\" + entry.Name.Replace("/", "\\");//获取物理文件的路径到文件
                    if (!Directory.Exists(directorName))  //判断存放解压出来的文件的存放目录是否存在
                    {
                        //创建文件夹的路径就是directorName的路径，创建文件夹时可以根据路径创建国歌文件夹
                        Directory.CreateDirectory(directorName);
                    }
                    //把一个流中的文件保存到磁盘上，首先是读取流中的数据字节， zis.read(data,0,data.length
                    using (FileStream stream = File.Create(fileName))
                    {
                        int size = 4096;//每次只是读取4096个字节
                        //设置缓冲区
                        byte[] data = new byte[4 * 1024];
                        //
                        while (true)
                        {
                            size = zis.Read(data, 0, data.Length);//这里时将zis的字节读取到data中
                            if (size > 0)
                            {
                                stream.Write(data, 0, size);//写入到文件中
                            }
                            else
                            {
                                break;
                            }

                        }
                    }
                }
            }
        }
        #endregion
    }
}

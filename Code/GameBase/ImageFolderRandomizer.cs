using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;

namespace CygX1.TwoWay.GameBaseEngine
{
    public class ImageFolderRandomizer
    {
        // Purpose is to accept a folder path of images. When the Next() function is
        // called, an image is randomly chosen and returned to the caller.

        // Images are loaded into a bitmap array so that time is not wasted collecting
        // an image file every time we want another image.


        DirectoryInfo targetFolder;
        private FileInfo[] imageFiles;
        private Bitmap[] bitmaps;
        Random rndm = new Random();

        public string Folder
        {
            get { return this.targetFolder.FullName; }
            set
            {
                targetFolder = new DirectoryInfo(value);
                collectImages(this.targetFolder.FullName);
            }
        }

        public Image Next()
        {
            int x = rndm.Next(imageFiles.Length);
            return bitmaps[x];
        }

        private void collectImages(string folder)
        {
            imageFiles = targetFolder.GetFiles("*.gif");
            bitmaps = new Bitmap[imageFiles.Length];

            for (int x = 0; x < imageFiles.Length; x++)
            {
                bitmaps[x] = new Bitmap(imageFiles[x].FullName);
                bitmaps[x].MakeTransparent(Color.Black);
            }
        }

        private void getValidImageFiles()
        {
            
        }
    }
}

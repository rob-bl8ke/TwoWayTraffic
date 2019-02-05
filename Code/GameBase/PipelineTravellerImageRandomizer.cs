using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;

namespace CygX1.TwoWay.GameBaseEngine
{
    public class PipelineTravellerImageRandomizer
    {
        DirectoryInfo targetFolder;
        private FileInfo[] travellerFiles;
        private Bitmap[] bitmaps;
        Random rndm = new Random();

        public string Folder
        {
            get { return this.targetFolder.FullName; }
            set
            {
                targetFolder = new DirectoryInfo(value);
                setupVehicles(this.targetFolder.FullName);
            }
        }

        public Image NextTraveller()
        {
            int x = rndm.Next(travellerFiles.Length);
            return bitmaps[x];
        }

        private void setupVehicles(string folder)
        {
            travellerFiles = targetFolder.GetFiles();
            bitmaps = new Bitmap[travellerFiles.Length];

            for (int x = 0; x < travellerFiles.Length; x++)
            {
                bitmaps[x] = new Bitmap(travellerFiles[x].FullName);
                bitmaps[x].MakeTransparent(Color.Black);
            }
        }
    }
}

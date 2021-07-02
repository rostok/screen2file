/*
	this simple tool will copy clipboard bitmap data to image file 
*/
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Globalization;
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

[assembly: AssemblyTitle("Screen2File")]
[assembly: AssemblyDescription("copies clipboard bitmap to image file")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("rostok - https://github.com/rostok/")]
[assembly: AssemblyProduct("Screen@file")]
[assembly: AssemblyCopyright("Copyright © 2021")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

namespace Screen2File
{

	public class App
	{
        [STAThread]
		static void Main(string[] args)
		{
			if (args.Length>0 && (args[0]=="/?" || args[0]=="--help" || args[0]=="-h"))
			{
                MessageBox.Show("correct syntax is: Screen2File.exe [image.jpg|image.png|.]");
				Environment.Exit(0);
			}
		    string extension = ".jpg";
			if (args.Length>0 && args[0].ToLower().EndsWith(".png")) extension = ".png";

            if (Clipboard.ContainsImage())
            {
                IDataObject data = Clipboard.GetDataObject();

                if (data.GetDataPresent(DataFormats.Bitmap))
                {
                    Image image = Clipboard.GetImage();

                    DateTime d = DateTime.Now;
                    string imagefile =  "image"+d.ToString("yyyy-MM-dd-HH-mm-ss")+extension;
                    image.Save(System.IO.Path.GetTempPath()+imagefile, extension==".jpg" ? System.Drawing.Imaging.ImageFormat.Jpeg : System.Drawing.Imaging.ImageFormat.Png );
                    Clipboard.SetDataObject( System.IO.Path.GetTempPath()+imagefile, true );
                    Console.WriteLine( System.IO.Path.GetTempPath()+imagefile );
                    if (args.Length==1)
                    if (args[0]==".")
                    	 System.IO.File.Copy(System.IO.Path.GetTempPath()+imagefile, imagefile);
                    else
                    	 System.IO.File.Copy(System.IO.Path.GetTempPath()+imagefile, args[0]);
                }
            }
            else
            {
                MessageBox.Show("Clipboard is empty or data is not an image");
            }
		}
	}
}
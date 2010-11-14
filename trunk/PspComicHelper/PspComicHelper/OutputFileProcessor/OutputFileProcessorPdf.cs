using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PspComicHelper.OutputFileProcessor
{
	/// <summary>
	/// 输出处理 Pdf实现
	/// </summary>
	public class OutputFileProcessorPdf : IOutputFileProcessor
	{
		/// <summary>
		/// 处理漫画到输出目录
		/// </summary>
		/// <param name="source"></param>
		/// <param name="dest"></param>
		public void ProcessComicToOutput( string source, string dest )
		{
			var files = Directory.GetFiles( source, "*.jpg", SearchOption.TopDirectoryOnly );
			iTextSharp.text.Document doc = new iTextSharp.text.Document(
				new iTextSharp.text.Rectangle( 480, 960 ),
				0, 0, 0, 0
			);
			iTextSharp.text.pdf.PdfWriter.GetInstance( doc,
				new FileStream( dest + ".pdf", FileMode.CreateNew, FileAccess.ReadWrite ) 
			);
			doc.Open();
			foreach ( string file in files )
			{
				System.Drawing.Image img = System.Drawing.Image.FromFile( file );
				var pdfImage = iTextSharp.text.Image.GetInstance( img, System.Drawing.Imaging.ImageFormat.Jpeg );
				pdfImage.Alignment = iTextSharp.text.Image.MIDDLE_ALIGN;
				doc.Add( pdfImage );
			}
			doc.Close();
		}

	}
}

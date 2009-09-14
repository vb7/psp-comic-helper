using System.Drawing;
using NUnit.Framework;

namespace PspComicHelper.Test
{
	[TestFixture]
	public class ImageHelper_Fixture
	{
		/// <summary>
		/// Í¼Ïñ±ßÔµ¼ì²â ²âÊÔ
		/// </summary>
		[Test]
		public void DetectMargin_Test()
		{
			Bitmap bitmap = new Bitmap( @"resources\DetectMargin_sample1.jpg" );
			ImageMargin margin = ImageHelper.DetectMargin( bitmap, 225 );
			Assert.AreEqual( 2, margin.Left );
			Assert.AreEqual( 2, margin.Top );
			Assert.AreEqual( 2, margin.Right );
			Assert.AreEqual( 2, margin.Bottom );
			bitmap.Dispose();
		}

		[Test]
		public void CutMargin_Specify_Test()
		{
			Bitmap bitmap = new Bitmap( @"resources\DetectMargin_sample1.jpg" );
			Bitmap cutted = ImageHelper.CutMargin( bitmap, new ImageMargin{ Left = 1, Top = 1, Right = 2, Bottom = 2 } );
			Assert.AreEqual( 7, cutted.Width );
			Assert.AreEqual( 7, cutted.Height );
			ImageHelper.SaveAsJpeg( cutted, "output1.jpg", 89 );
			bitmap.Dispose();
			cutted.Dispose();
		}


		[Test]
		public void CutMargin_Auto_Test()
		{
			// ºÚ°×Í¼
			Bitmap bitmap = new Bitmap( @"resources\DetectMargin_sample1.jpg" );
			Bitmap cutted = ImageHelper.CutMargin( bitmap, 200 );
			Assert.AreEqual( 6, cutted.Width );
			Assert.AreEqual( 6, cutted.Height );
			ImageHelper.SaveAsJpeg( cutted, "output2.jpg", 89 );
			bitmap.Dispose();
			cutted.Dispose();

			// ²ÊÉ«Í¼
			bitmap = new Bitmap( @"resources\DetectMargin_sample2.jpg" );
			cutted = ImageHelper.CutMargin( bitmap, 225 );
			Assert.AreEqual( 6, cutted.Width );
			Assert.AreEqual( 6, cutted.Height );
			cutted.Save( "output3.bmp", System.Drawing.Imaging.ImageFormat.Bmp );
			//ImageHelper.SaveAsJpeg( cutted, "output3.jpg", 89 );
			bitmap.Dispose();
			cutted.Dispose();

			// »Ò¶ÈÍ¼
			bitmap = new Bitmap( @"resources\DetectMargin_sample3.jpg" );
			cutted = ImageHelper.CutMargin( bitmap, 240 );
			Assert.AreEqual( 6, cutted.Width );
			Assert.AreEqual( 6, cutted.Height );
			cutted.Save( "output4.bmp", System.Drawing.Imaging.ImageFormat.Bmp );
			ImageHelper.SaveAsJpeg( cutted, "output4.jpg", 89 );
			bitmap.Dispose();
			cutted.Dispose();
		}

		/// <summary>
		/// ¼ÆËã¿í¸ß ²âÊÔ
		/// </summary>
		[Test]
		public void CalcSize_Test()
		{
			int width, height, newWidth, newHeight;

			width = 480;
			height = 0;
			ImageHelper.CalcSize( 2000, 3000, width, height, out newWidth, out newHeight, ImageHelper.ResizeMode.Scale );
			Assert.AreEqual( 480, newWidth );
			Assert.AreEqual( 720, newHeight );

			width = 0;
			height = 512;
			ImageHelper.CalcSize( 2000, 3000, width, height, out newWidth, out newHeight, ImageHelper.ResizeMode.Scale );
			Assert.AreEqual( 341, newWidth );
			Assert.AreEqual( 512, newHeight );

			width = 500;
			height = 500;
			ImageHelper.CalcSize( 1000, 2000, width, height, out newWidth, out newHeight, ImageHelper.ResizeMode.Scale );
			Assert.AreEqual( 250, newWidth );
			Assert.AreEqual( 500, newHeight );

			width = 200;
			height = 200;
			ImageHelper.CalcSize( 5685, 3695, width, height, out newWidth, out newHeight, ImageHelper.ResizeMode.Stretch );
			Assert.AreEqual( 200, newWidth );
			Assert.AreEqual( 200, newHeight );

			width = 500;
			height = 500;
			ImageHelper.CalcSize( 1000, 2000, width, height, out newWidth, out newHeight, ImageHelper.ResizeMode.Center );
			Assert.AreEqual( 500, newWidth );
			Assert.AreEqual( 1000, newHeight );
		}

	}
}
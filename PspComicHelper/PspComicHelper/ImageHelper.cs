using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace PspComicHelper
{
	/// <summary>
	/// 图片处理类
	/// </summary>
	public class ImageHelper
	{
		/// <summary>
		/// 得到指定mimeType的ImageCodecInfo
        /// </summary>
        /// <param name="mimeType"></param>
        /// <returns>得到指定mimeType的ImageCodecInfo</returns>
        private static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo ici in CodecInfo)
            {
                if (ici.MimeType == mimeType) return ici;
            }
            return null;
        }

		/// <summary>
        /// 保存为JPEG格式，支持压缩质量选项
        /// </summary>
        /// <param name="bmp"></param>
		/// <param name="filename"></param>
		/// <param name="quality"></param>
        /// <returns></returns>
        public static bool SaveAsJpeg(Bitmap bmp, string filename, int quality)
        {
            EncoderParameter p;
            EncoderParameters ps;

            ps = new EncoderParameters(1);

            p = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            ps.Param[0] = p;

            bmp.Save(filename, GetCodecInfo("image/jpeg"), ps);
            
            return true;

        }


		/// <summary>
		/// 调整大小
		/// </summary>
		/// <param name="bmp">原始Bitmap</param>
		/// <param name="newW">新的宽度</param>
		/// <param name="newH">新的高度</param>
		/// <param name="Mode">保留着，暂时未用</param>
		/// <returns>处理以后的图片</returns>
		public static Bitmap Resize( Bitmap bmp, int width, int height, ResizeMode mode )
		{

			int newWidth, newHeight;
			switch ( mode )
			{
				case ResizeMode.Stretch :
					newWidth = width;
					newHeight = height;
					break;

				case ResizeMode.Center :
					throw new NotImplementedException( "缩放模式居中的方法暂未实现" );
					break;

				case ResizeMode.Scale :
				default :
					if ( width == 0 )
					{
						newWidth = (int)( (float)height * ( (float)bmp.Width / (float)bmp.Height ) );
						newHeight = height;
					}
					else if( height == 0 )
					{
						newWidth = width;
						newHeight = (int)( (float)width * ( (float)bmp.Height / (float)bmp.Width ) );
					}
					else if ( ( (float)width / (float)height ) > ( (float)bmp.Width / (float)bmp.Height ) )
					{
						newWidth = (int)( (float)height * ( (float)bmp.Width / (float)bmp.Height ) );
						newHeight = height;
					}
					else
					{
						newWidth = width;
						newHeight = (int)( (float)width * ( (float)bmp.Height / (float)bmp.Width ) );
					}

					// 如果使用等比缩放模式, 新的宽,高大于原图的宽,高,不做操作
					if ( newWidth > bmp.Width || height > bmp.Height )
					{
						return bmp;
					}

					break;

			}

			Bitmap b = new Bitmap( newWidth, newHeight );
			Graphics g = Graphics.FromImage( b );

			// 插值算法的质量
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

			g.DrawImage( bmp, new Rectangle( 0, 0, newWidth, newHeight ), new Rectangle( 0, 0, bmp.Width, bmp.Height ), GraphicsUnit.Pixel );
			g.Dispose();

			return b;
		}


		/// <summary>
		/// 剪裁
		/// </summary>
		/// <param name="bitmap">原始Bitmap</param>
		/// <param name="startX">开始坐标X</param>
		/// <param name="startY">开始坐标Y</param>
		/// <param name="width">宽度</param>
		/// <param name="height">高度</param>
		/// <returns>剪裁后的Bitmap</returns>
		public static Bitmap Cut( Bitmap bitmap, int startX, int startY, int width, int height )
		{
			if ( bitmap == null )
			{
				return null;
			}

			int w = bitmap.Width;
			int h = bitmap.Height;

			if ( startX >= w || startY >= h )
			{
				return null;
			}

			if ( startX + width > w )
			{
				width = w - startX;
			}

			if ( startY + height > h )
			{
				height = h - startY;
			}

			Bitmap bmpOut = new Bitmap( width, height, PixelFormat.Format24bppRgb );

			Graphics g = Graphics.FromImage( bmpOut );
			g.DrawImage( bitmap, new Rectangle( 0, 0, width, height ), new Rectangle( startX, startY, width, height ), GraphicsUnit.Pixel );
			g.Dispose();

			return bmpOut;
		}


		/// <summary>
		/// 检测图像边缘
		/// </summary>
		/// <param name="bitmap"></param>
		/// <param name="threshold"></param>
		/// <returns></returns>
		public static ImageMargin DetectMargin( Bitmap bitmap, int threshold )
		{
			
			if ( threshold > 255 || threshold < 0 )
				threshold = 255;
			int left = -1 , top = -1, right = -1, bottom = -1;
			int brightness;

			// 检测左边缘
			for ( int x = 0; x < bitmap.Width; x++ )
			{
				for ( int y = 0; y < bitmap.Height; y++ )
				{
					brightness = (int)( bitmap.GetPixel( x, y ).GetBrightness() * 255 );
					if ( brightness <= threshold )
					{
						left = x;
						break;
					}
				}
				if( left >= 0 )
					break;
			}

			// 检测上边缘
			for ( int y = 0; y < bitmap.Height; y++ )
			{
				for ( int x = left; x < bitmap.Width; x++ )
				{
					brightness = (int)( bitmap.GetPixel( x, y ).GetBrightness() * 255 );
					if ( brightness <= threshold )
					{
						top = y;
						break;
					}
				}
				if( top >= 0 )
					break;
			}

			// 检测右边缘
			for ( int x = bitmap.Width - 1; x > left; x-- )
			{
				for ( int y = top; y < bitmap.Height; y++ )
				{
					brightness = (int)( bitmap.GetPixel( x, y ).GetBrightness() * 255 );
					if ( brightness <= threshold )
					{
						right = bitmap.Width - 1 - x;
						break;
					}
				}
				if( right >= 0 )
					break;
			}

			// 检测下边缘
			for ( int y = bitmap.Height - 1; y > top; y-- )
			{
				for ( int x = left; x < bitmap.Width - 1 - right; x++ )
				{
					brightness = (int)( bitmap.GetPixel( x, y ).GetBrightness() * 255 );
					if ( brightness <= threshold )
					{
						bottom = bitmap.Height - 1 - y;
						break;
					}
				}
				if( bottom >= 0 )
					break;
			}

			return new ImageMargin{ Left = left, Top = top, Right = right, Bottom = bottom };
		}


		/// <summary>
		/// 裁剪边缘 指定边缘
		/// </summary>
		/// <param name="bitmap"></param>
		/// <param name="margin"></param>
		/// <returns></returns>
		public static Bitmap CutMargin( Bitmap bitmap, ImageMargin margin )
		{
			return Cut( bitmap, margin.Left, margin.Top,
				bitmap.Width - margin.Left - margin.Right,
				bitmap.Height - margin.Top - margin.Bottom );
		}

		/// <summary>
		/// 裁剪边缘 自动检测
		/// </summary>
		/// <param name="bitmap"></param>
		/// <param name="threshold"></param>
		/// <returns></returns>
		public static Bitmap CutMargin( Bitmap bitmap, int threshold )
		{
			return CutMargin( bitmap, DetectMargin( bitmap, threshold ) );
		}


		/// <summary>
		/// 图片缩放模式
		/// </summary>
		public enum ResizeMode
		{
			/// <summary>
			/// 等比
			/// </summary>
			Scale,

			/// <summary>
			/// 拉伸
			/// </summary>
			Stretch,

			/// <summary>
			/// 居中
			/// </summary>
			Center
		}


	}
}

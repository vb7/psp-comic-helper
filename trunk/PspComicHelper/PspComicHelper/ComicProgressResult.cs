namespace PspComicHelper
{
	/// <summary>
	/// 漫画处理结果
	/// </summary>
	public enum ComicProgressResult
	{
		/// <summary>
		/// 完成
		/// </summary>
		Complete = 1,

		/// <summary>
		/// 路径错误
		/// </summary>
		PathError = 2,

		/// <summary>
		/// 不支持的压缩格式
		/// </summary>
		UnsupportedArchive = 3,

		/// <summary>
		/// 目录内无图片
		/// </summary>
		NoneImageInFolder = 4
	}
}
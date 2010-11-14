using System;
using System.Collections.Generic;
using System.Text;

namespace PspComicHelper.OutputFileProcessor
{
	/// <summary>
	/// 输出处理接口
	/// </summary>
	public interface IOutputFileProcessor
	{
		/// <summary>
		/// 处理漫画到输出目录
		/// </summary>
		/// <param name="source"></param>
		/// <param name="dest"></param>
		void ProcessComicToOutput( string source, string dest );
	}
}

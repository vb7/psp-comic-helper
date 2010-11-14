using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using PspComicHelper.OutputFileProcessor;

namespace PspComicHelper.Test
{
	[TestFixture]
	public class OutputFileProcessorPdf_Fixture
	{
		IOutputFileProcessor output = new OutputFileProcessorPdf();

		[Test]
		public void ProcessComicToOutput_Test()
		{
			output.ProcessComicToOutput( @"resources\pdfimage", @"resources\pdfimage\output" );
		}
	}
}

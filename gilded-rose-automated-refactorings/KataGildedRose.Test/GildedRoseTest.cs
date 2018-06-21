using System;
using System.IO;
using Xunit;

namespace KataGildedRose.Tests
{
    public class GildedRoseTest
    {
        private TextWriter originalConsoleOut;
        private StreamWriter fileWriter;

        [Fact]
        public void The_Behaviour_Should_Not_Be_Changed()
        {
            ChangeSystemOutTo("../../current.log");

            SampleExecution.Main(new String[] { });

            RevertSystemOut();
            AssertFilesAreEqual(
                "../../original.log",
                "../../current.log"
            );

        }
        private void ChangeSystemOutTo(String Path)
        {
            originalConsoleOut = Console.Out;
            fileWriter = new StreamWriter(Path, false);
            Console.SetOut(fileWriter);
        }

        private void RevertSystemOut()
        {
            fileWriter.Close();
            Console.SetOut(originalConsoleOut);
        }

        private static void AssertFilesAreEqual(String expectedFilePath, String actualFilePath)
        {
            Assert.Equal(ReadFile(expectedFilePath), ReadFile(actualFilePath));
        }

        private static string ReadFile(string actualFilePath)
        {
            return File.ReadAllText(actualFilePath);
        }
    }
}

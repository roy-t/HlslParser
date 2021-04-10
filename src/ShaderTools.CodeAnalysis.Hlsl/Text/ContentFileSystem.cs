using System.IO;
using Microsoft.CodeAnalysis.Text;

namespace ShaderTools.CodeAnalysis.Hlsl.Text
{
    public sealed class ContentFileSystem : IIncludeFileSystem
    {
        public bool TryGetFile(string path, out SourceText text)
        {
            var sourceCode = File.ReadAllText(path);
            text = SourceText.From(sourceCode);
            return true;
        }
    }
}

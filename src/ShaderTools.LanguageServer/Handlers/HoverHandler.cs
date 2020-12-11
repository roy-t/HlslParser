﻿using System.Threading;
using System.Threading.Tasks;
using OmniSharp.Extensions.LanguageServer.Protocol.Client.Capabilities;
using OmniSharp.Extensions.LanguageServer.Protocol.Document;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;
using ShaderTools.CodeAnalysis;
using ShaderTools.CodeAnalysis.QuickInfo;
using Range = OmniSharp.Extensions.LanguageServer.Protocol.Models.Range;

namespace ShaderTools.LanguageServer.Handlers
{
    internal sealed class HoverHandler : HoverHandlerBase
    {
        private readonly LanguageServerWorkspace _workspace;
        private readonly DocumentSelector _documentSelector;

        public HoverHandler(LanguageServerWorkspace workspace, DocumentSelector documentSelector)
        {
            _workspace = workspace;
            _documentSelector = documentSelector;
        }

        protected override HoverRegistrationOptions CreateRegistrationOptions(HoverCapability capability, ClientCapabilities clientCapabilities)
        {
            return new HoverRegistrationOptions
            {
                DocumentSelector = _documentSelector
            };
        }

        public override async Task<Hover> Handle(HoverParams request, CancellationToken token)
        {
            var (document, position) = _workspace.GetLogicalDocument(request);

            var quickInfoService = document.LanguageServices.GetRequiredService<QuickInfoService>();

            var item = await quickInfoService.GetQuickInfoAsync(document, position, token);

            if (item != null)
            {
                Range symbolRange;

                var content = item.Content;
                var markdownText = $"``` {Helpers.ToLspLanguage(document.Language)}\n{content.MainDescription.GetFullText()}\n```\n";

                if (!content.Documentation.IsEmpty)
                {
                    markdownText += "---\n";
                    markdownText += content.Documentation.GetFullText();
                }

                symbolRange = Helpers.ToRange(document.SourceText, item.TextSpan);

                return new Hover
                {
                    Contents = new MarkedStringsOrMarkupContent(new MarkupContent { Kind = MarkupKind.Markdown, Value = markdownText }),
                    Range = symbolRange
                };
            }
            else
            {
                return new Hover();
            }
        }
    }
}

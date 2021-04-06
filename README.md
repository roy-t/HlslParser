# HLSL Parser for C#

Fork of [HlslTools](https://github.com/tgjones/HlslTools) created by [@tgjones](https://github.com/tgjones). This fork extracts the HLSL parser so it can be used in other projects.

### Acknowledgements

* Hand written HLSL parser by [@tgjones](https://github.com/tgjones)
* Much of the code structure, and some of the actual code, comes from [Roslyn](https://github.com/dotnet/roslyn).
* [NQuery-vnext](https://github.com/terrajobst/nquery-vnext) is a nice example of a simplified Roslyn-style API,
  and HLSL Tools borrows some of its ideas and code.
* [Node.js Tools for Visual Studio](https://github.com/Microsoft/nodejstools) and
  [Python Tools for Visual Studio](https://github.com/Microsoft/PTVS) are amongst the best examples of how to build
  a language service for Visual Studio, and were a great help.
* [ScriptSharp](https://github.com/nikhilk/scriptsharp) is one of the older open-source .NET-related compilers,
  and is still a great example of how to structure a compiler.
* [LangSvcV2](https://github.com/tunnelvisionlabs/LangSvcV2) includes many nice abstractions for some of the more
  complicated parts of Visual Studio's language service support.
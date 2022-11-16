# CLSS.ExtensionMethods.IDictionary.GetOrAdd

### Problem

[`GetOrAdd`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentdictionary-2.getoradd) is a convenient method for `ConcurrentDictionary` but not for other `IDictionary` types in the standard class library. This method is often used to cache results of pure functions, ie functions that always yield a deterministic result for each argument.

### Solution

This package provides `GetOrAdd` method to all `IDictionary` types.

Example:

```csharp
using CLSS;

var NumberSpellings = new Dictionary<int, string>();
Func<int, string> NumberToSpelling = n => { /* Implementation */ };
var spelling_285 = NumberSpellings.GetOrAdd(285, NumberToSpelling);
```

##### This package is a part of the [C# Language Syntactic Sugar suite](https://github.com/tonygiang/CLSS).
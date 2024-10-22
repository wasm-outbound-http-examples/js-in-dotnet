# Use Jint JS interpreter to send HTTP(s) requests from inside WASM in browser

## Instructions for this devcontainer

Tested with .Net version 8.0.402, Jint [v4.0.3](https://github.com/sebastienros/jint/releases/tag/v4.0.3).

> [!NOTE]
> Note that printing to console currently is made from C# code. Returning the result to JS by using `result.UnwrapIfPromise()`
> looks like still impossible, probably due to [`Error: Cannot wait on monitors on this runtime.`](https://github.com/dotnet/runtime/issues/51115#issuecomment-817805961).

### Preparation

1. Open this repo in devcontainer, e.g. using Github Codespaces.
   Type or copy/paste following commands to devcontainer's terminal.

2. Install .Net workloads to handle WASM:

```sh
dotnet workload install wasm-tools
dotnet workload install wasm-experimental
```

### Building

1. `cd` into the folder of this example:

```sh
cd browser-and-node-Jint/browser
```

2. Create new .Net project using `wasmbrowser` template:

```sh
dotnet new wasmbrowser
```

3. Install Jint package as dependency:

```sh
dotnet add package Jint --version 4.0.3
```

4. Replace generated HelloWorld-like `Program.cs` and `wwwroot` contents with HTTP-enabled ones:

```sh
cp ../Program.cs ./
cp ../index.html ./wwwroot/
cp ../main.js ./wwwroot/
```

5. Compile the example:

```sh
dotnet build
```

### Test with browser

1. Generate bunch of self-signed development SSL certificates:

```sh
dotnet dev-certs https
```

2. Run debug HTTP server to temporarily publish project to Web:

```sh
dotnet run
```

Codespace will show you "Open in Browser" button. Just click that button or
obtain web address from "Forwarded Ports" tab.

3. As `index.html` and about **23MB** of js and wasm files are loaded into browser, refer to browser developer console
   to see the results.


4. If you want to publish this on your own server, you can run bundling by:

```sh
dotnet publish -c Release
```

### Finish

Perform your own experiments if desired.

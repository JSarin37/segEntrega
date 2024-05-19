using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#if __ANDROID__
using Android.App;

[assembly: UsesFeature("android.hardware.camera", Required = false)]
[assembly: UsesFeature("android.hardware.camera.autofocus", Required = false)]
#endif


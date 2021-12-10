using System.Runtime.InteropServices;

using (var res = Native.new_err()) {
    if (Native.result_is_ok(res)) {
        res.Unwrap();
    }
}
Console.WriteLine("Success!");

internal class Native {
    [DllImport("fficrashlib")] internal static extern Result new_err();
    [DllImport("fficrashlib")] internal static extern void result_free(IntPtr res);
    [DllImport("fficrashlib")] internal static extern bool result_is_ok(Result res);
    [DllImport("fficrashlib")] internal static extern Unit result_unwrap(IntPtr res);
    [DllImport("fficrashlib")] internal static extern void unit_free(IntPtr unit);
}

internal class Result : SafeHandle {
    internal Result() : base(IntPtr.Zero, true) {}

    public override bool IsInvalid {
        get { return this.handle == IntPtr.Zero; }
    }

    protected override bool ReleaseHandle() {
        if (!this.IsInvalid) {
            Native.result_free(this.handle);
        }
        return true;
    }

    internal Unit Unwrap() {
        var unit = Native.result_unwrap(this.handle);
        this.handle = IntPtr.Zero;
        return unit;
    }
}

internal class Unit : SafeHandle {
    internal Unit() : base(IntPtr.Zero, true) {}

    public override bool IsInvalid {
        get { return this.handle == IntPtr.Zero; }
    }

    protected override bool ReleaseHandle() {
        if (!this.IsInvalid) {
            Native.unit_free(this.handle);
        }
        return true;
    }
}

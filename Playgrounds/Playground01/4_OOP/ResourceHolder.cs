using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace _4_OOP
{
    class ResourceHolder : IDisposable
    {
        private readonly IntPtr _unmanagedResource;
        private readonly SafeHandle _managedResource;

        public ResourceHolder()
        {
            _unmanagedResource = Marshal.AllocHGlobal(sizeof(int));
            _managedResource = new SafeFileHandle(new IntPtr(), true);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isManualDisposing)
        {
            ReleaseManagedResource(_managedResource);
            if (isManualDisposing)
            {
                ReleaseUnmanagedResource(_unmanagedResource);
            }
        }

        private void ReleaseManagedResource(SafeHandle safeHandle)
        {
            safeHandle?.Dispose();
        }

        private void ReleaseUnmanagedResource(IntPtr intPtr)
        {
            Marshal.FreeHGlobal(intPtr);
        }

        ~ResourceHolder()
        {
            Dispose(false);
        }
    }

    class ResourceHolder2 : IDisposable
    {
        private readonly SafeHandle _managedResource;

        public ResourceHolder2()
        {
            _managedResource = new SafeFileHandle(new IntPtr(), true);
        }

        public void Dispose()
        {
            _managedResource?.Dispose();
            // ? - if not null
            // if (_managedResource != null)
            //     _managedResource.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}

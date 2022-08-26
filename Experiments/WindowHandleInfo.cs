using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Experiments
{
  public static class WindowsInfoProvider
  {
    public static List<IntPtr> GetMainWindows()
    {
      List<IntPtr> childHandles = new List<IntPtr>();

      GCHandle gcChildHandlesList = GCHandle.Alloc(childHandles);
      IntPtr pointerChildHandlesList = GCHandle.ToIntPtr(gcChildHandlesList);

      try
      {
        WinApi.EnumWindowProc childProc = new WinApi.EnumWindowProc(EnumWindow);
        WinApi.EnumWindows(childProc, pointerChildHandlesList);
      }
      finally
      {
        gcChildHandlesList.Free();
      }

      return childHandles;
    }

    public static string GetTitle(IntPtr handle, StringBuilder buffer)
    {
      WinApi.GetWindowText(handle, buffer, buffer.Capacity);
      var result = buffer.ToString();
      buffer.Clear();
      return result;
    }

    public static List<IntPtr> GetAllChildHandles(IntPtr handle)
    {
      List<IntPtr> childHandles = new List<IntPtr>();

      GCHandle gcChildHandlesList = GCHandle.Alloc(childHandles);
      IntPtr pointerChildHandlesList = GCHandle.ToIntPtr(gcChildHandlesList);

      try
      {
        WinApi.EnumWindowProc childProc = new WinApi.EnumWindowProc(EnumWindow);
        WinApi.EnumChildWindows(handle, childProc, pointerChildHandlesList);
      }
      finally
      {
        gcChildHandlesList.Free();
      }

      return childHandles;
    }

    public static bool EnumWindow(IntPtr hWnd, IntPtr lParam)
    {
      GCHandle gcChildHandlesList = GCHandle.FromIntPtr(lParam);

      if (gcChildHandlesList == null || gcChildHandlesList.Target == null)
      {
        return false;
      }

      List<IntPtr> childHandles = gcChildHandlesList.Target as List<IntPtr>;
      childHandles.Add(hWnd);

      return true;
    }
  }
}

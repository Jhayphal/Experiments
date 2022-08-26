using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;

namespace Experiments
{
  internal class Program
  {
    static void DrawProcess(string text)
    {
      var mainWindows = WindowsInfoProvider.GetMainWindows();
      var buffer = new StringBuilder(byte.MaxValue);

      foreach (var handle in mainWindows)
      {
        if (WindowsInfoProvider.GetTitle(handle, buffer).Contains(text))
        {
          AutomationElement browserMainWindow = AutomationElement.FromHandle(handle);

          DrawControlsTree(browserMainWindow);

          break;
        }
      }
    }

    static void DrawControlsTree(AutomationElement element, int level = 0)
    {
      var elementNode = TreeWalker.ControlViewWalker.GetFirstChild(element);

      while (elementNode != null)
      {
        Console.Write(new string('-', level << 2));
        Console.WriteLine(string.IsNullOrEmpty(elementNode.Current.Name) ? elementNode.Current.LocalizedControlType : elementNode.Current.Name);

        DrawControlsTree(elementNode, level + 1);

        elementNode = TreeWalker.ControlViewWalker.GetNextSibling(elementNode);
      }
    }

    static void Main()
    {
      Console.OutputEncoding = Encoding.UTF8;
      
      //DrawWindowsHierarchy();
      DrawProcess("Google Chrome");

      Console.ReadLine();
    }

    static void DrawWindowsHierarchy()
    {
      var mainWindows = WindowsInfoProvider.GetMainWindows();
      var buffer = new StringBuilder(256);

      foreach (var handle in mainWindows)
      {
        var title = WindowsInfoProvider.GetTitle(handle, buffer);

        //if (string.IsNullOrWhiteSpace(title))
        //  continue;

        Console.WriteLine(title);

        DrawChildren(handle, buffer, level: 1);
      }
    }

    static void DrawChildren(IntPtr handle, StringBuilder buffer, int level)
    {
      var children = WindowsInfoProvider.GetAllChildHandles(handle);

      foreach (var childHandle in children)
      {
        var title = WindowsInfoProvider.GetTitle(childHandle, buffer);

        //if (string.IsNullOrWhiteSpace(title))
        //  continue;

        Console.WriteLine($"{new string('-', level << 2)}{title}");

        DrawChildren(childHandle, buffer, level + 1);
      }
    }
  }
}

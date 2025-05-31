using System.Runtime.InteropServices;

namespace WebClicker.Services;

public class KeyboardService
{
    [DllImport("user32.dll")]
    static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

    private const int KEYEVENTF_KEYDOWN = 0x0000;
    private const int KEYEVENTF_KEYUP = 0x0002;
    private const int VK_PRIOR = 0x21; // Page Up
    private const int VK_NEXT = 0x22;  // Page Down
    private const int VK_LEFT = 0x25;  // Left Arrow
    private const int VK_RIGHT = 0x27; // Right Arrow

    public void NextSlide()
    {
        keybd_event(VK_RIGHT, 0, KEYEVENTF_KEYDOWN, 0);
        Thread.Sleep(50);
        keybd_event(VK_RIGHT, 0, KEYEVENTF_KEYUP, 0);
    }

    public void PreviousSlide()
    {
        keybd_event(VK_LEFT, 0, KEYEVENTF_KEYDOWN, 0);
        Thread.Sleep(50);
        keybd_event(VK_LEFT, 0, KEYEVENTF_KEYUP, 0);
    }

    // Backup methods for page navigation
    public void NextSlidePageDown()
    {
        keybd_event(VK_NEXT, 0, KEYEVENTF_KEYDOWN, 0);
        Thread.Sleep(50);
        keybd_event(VK_NEXT, 0, KEYEVENTF_KEYUP, 0);
    }

    public void PreviousSlidePageUp()
    {
        keybd_event(VK_PRIOR, 0, KEYEVENTF_KEYDOWN, 0);
        Thread.Sleep(50);
        keybd_event(VK_PRIOR, 0, KEYEVENTF_KEYUP, 0);
    }
}
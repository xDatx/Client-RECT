using ImGuiNET;
using ClickableTransparentOverlay;
using System.Numerics;
using static WindowRect.Program;
namespace WindowRect
{
    class RenderTest : Overlay
    {
        protected override void Render()
        {
            ImGui.SetNextWindowPos(new Vector2(rectT.left, rectT.top));
            ImGui.SetNextWindowSize(new Vector2(rectT.right, rectT.bottom));
            ImGui.Begin("Test");
            ImGui.End();
            
        }
    }
}

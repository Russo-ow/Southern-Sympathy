using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirUtility {
    public enum RotateDir { CW, CCW };
    public enum Dir { Up, Down, Left, Right };

    public static Dir NextDir(RotateDir rotateDir, Dir dir) {
        switch(dir) {
            case Dir.Up:
                return rotateDir == RotateDir.CW ? Dir.Right : Dir.Left;
            case Dir.Down:
                return rotateDir == RotateDir.CW ? Dir.Left : Dir.Right;
            case Dir.Left:
                return rotateDir == RotateDir.CW ? Dir.Up : Dir.Down;
            case Dir.Right:
                return rotateDir == RotateDir.CW ? Dir.Down : Dir.Up;
        }
        return Dir.Up;
    }
}

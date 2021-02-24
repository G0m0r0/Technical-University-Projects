package com.java24hours;

import java.awt.*;
import javax.swing.*;
 
public class FreeSpaceFrame extends JFrame {
    public FreeSpaceFrame() {
        super("Disk Free Space");
        setLookAndFeel();
        setSize(500, 120);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        FlowLayout flo = new FlowLayout();
        setLayout(flo);
        FreeSpacePanel freePanel = new FreeSpacePanel();
        add(freePanel);
        setVisible(true);
    }
 
    private void setLookAndFeel() {
        try {
            UIManager.setLookAndFeel(
                "javax.swing.plaf.nimbus.NimbusLookAndFeel"
            );
        } catch (Exception exc) {
            // ignore error
        }
    }
         
    public static void main(String[] arguments) {
        FreeSpaceFrame frame = new FreeSpaceFrame();
    }
}

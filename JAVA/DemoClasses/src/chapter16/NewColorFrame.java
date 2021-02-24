package com.java24hours;

import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

public class NewColorFrame extends JFrame {
    JButton red, green, blue;
    
    public NewColorFrame() {
        super("NewColorFrame");
        setSize(322, 122);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        FlowLayout flo = new FlowLayout();
        setLayout(flo);
        red = new JButton("Red");
        add(red);
        green = new JButton("Green");
        add(green);
        blue = new JButton("Blue");
        add(blue);
        // begin lambda expression
        ActionListener act = (event) -> {
            if (event.getSource() == red) {
                getContentPane().setBackground(Color.RED);
            }
            if (event.getSource() == green) {
                getContentPane().setBackground(Color.GREEN);
            }
            if (event.getSource() == blue) {
                getContentPane().setBackground(Color.BLUE);
            }
        };
        // end lambda expression
        red.addActionListener(act);
        green.addActionListener(act);
        blue.addActionListener(act);
        setVisible(true);
    }
 
    public static void main(String[] arguments) {
        new NewColorFrame();
    }
}

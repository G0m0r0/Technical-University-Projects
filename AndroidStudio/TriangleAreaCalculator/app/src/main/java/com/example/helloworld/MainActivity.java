package com.example.helloworld;

import static java.lang.Math.sqrt;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // format code ctrl+alt+L
    }

    public void onBtnCalculator(View view) {
        TextView txtCalculator = findViewById(R.id.txtCalculator); //resources.id.idName

        double area = (double) Math.round(calculateArea() * 100) / 100;

        txtCalculator.setText(String.format("Area of triangle is %s m2.", area));
    }

    private double calculateArea() {
        EditText txt1 = findViewById(R.id.txtUserA);
        double a = Double.parseDouble(txt1.getText().toString());
        EditText txt2 = findViewById(R.id.txtUserB);
        double b = Double.parseDouble(txt2.getText().toString());
        EditText txt3 = findViewById(R.id.txtUserC);
        double c = Double.parseDouble(txt3.getText().toString());
        double s = (a + b + c) / 2;

        double area = sqrt(s * (s - a) * (s - b) * (s - c));

        return area;
    }
}
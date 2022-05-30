package com.dimitrov.delyan.phonebook;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class AddActivity extends AppCompatActivity {

    EditText fName, lName, phoneNum;
    Button addBtn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add);

        fName = findViewById(R.id.fName);
        lName = findViewById(R.id.lName);
        phoneNum = findViewById(R.id.phoneNum);

        addBtn = findViewById(R.id.add_button);
        addBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                MyDatabaseHelper db = new MyDatabaseHelper(AddActivity.this);
                db.addBook(fName.getText().toString().trim(),
                        lName.getText().toString().trim(),
                        Integer.valueOf(phoneNum.getText().toString().trim()));
            }
        });
    }
}

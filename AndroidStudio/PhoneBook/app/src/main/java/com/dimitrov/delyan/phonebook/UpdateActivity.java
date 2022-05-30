package com.dimitrov.delyan.phonebook;

import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.content.DialogInterface;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class UpdateActivity extends AppCompatActivity {

    EditText fName_input, lName_input, phoneNum;
    Button update_button, delete_button;

    String id, fName, lName, phone;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_update);

        fName_input = findViewById(R.id.fName2);
        lName_input = findViewById(R.id.lName2);
        phoneNum = findViewById(R.id.phoneNum2);
        update_button = findViewById(R.id.update_button);
        delete_button = findViewById(R.id.delete_button);

        getAndSetIntentData();

        ActionBar ab = getSupportActionBar();
        if (ab != null) {
            ab.setTitle(fName);
        }

        update_button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                MyDatabaseHelper myDB = new MyDatabaseHelper(UpdateActivity.this);
                fName = fName_input.getText().toString().trim();
                lName = lName_input.getText().toString().trim();
                phone = phoneNum.getText().toString().trim();
                myDB.updateData(id, fName, lName, phone);
            }
        });
        delete_button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                confirmDialog();
            }
        });

    }

    void getAndSetIntentData(){
        if(getIntent().hasExtra("id") && getIntent().hasExtra("fName") &&
                getIntent().hasExtra("lName") && getIntent().hasExtra("phoneNum")){

            id = getIntent().getStringExtra("id");
            fName = getIntent().getStringExtra("fName");
            lName = getIntent().getStringExtra("lName");
            phone = getIntent().getStringExtra("phoneNum");


            fName_input.setText(fName);
            lName_input.setText(lName);
            phoneNum.setText(phone);
            Log.d("stev", fName+" "+lName+" "+phone);
        }else{
            Toast.makeText(this, "No data.", Toast.LENGTH_SHORT).show();
        }
    }

    void confirmDialog(){
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("Delete " + fName + " ?");
        builder.setMessage("Are you sure you want to delete " + fName + " ?");
        builder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialogInterface, int i) {
                MyDatabaseHelper myDB = new MyDatabaseHelper(UpdateActivity.this);
                myDB.deleteOneRow(id);
                finish();
            }
        });
        builder.setNegativeButton("No", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialogInterface, int i) {

            }
        });
        builder.create().show();
    }
}

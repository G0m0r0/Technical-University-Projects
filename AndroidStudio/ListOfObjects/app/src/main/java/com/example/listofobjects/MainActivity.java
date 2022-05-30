package com.example.listofobjects;

import androidx.appcompat.app.AppCompatActivity;

import android.app.Person;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.Toast;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {

    private ListView familyList;
    private Spinner studentsSpinner;

    public class Person {
        public Person(String fName, String lName, int age, String position) {
            firstName = fName;
            lastName = lName;
            this.age = age;
            this.position = position;
        }

        private String firstName;
        private String lastName;
        private int age;
        private String position;

        public String getInfo() {
            return "This is " + firstName + " at age " + age + ". " + position + " of family " + lastName + "i.";
        }

        @Override
        public String toString() {
            return this.firstName + " " + this.lastName;
        }
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        familyList = findViewById(R.id.familyList);
        studentsSpinner = findViewById(R.id.studentsSpinner);

        ArrayList<String> students = new ArrayList<>();
        students.add("Nike");
        students.add("Puma");
        students.add("Costa");
        students.add("Tom");

        Person person1 = new Person("Pesho", "Ivanov", 33, "Father");
        Person person2 = new Person("Maria", "Ivanova", 29, "Mother");
        Person person3 = new Person("Milko", "Ivanov", 13, "Son");


        final ArrayList<Person> persons = new ArrayList<>();
        persons.add(person1);
        persons.add(person2);
        persons.add(person3);

        ArrayAdapter<String> studentsAdapter = new ArrayAdapter<>(
                this,
                android.R.layout.simple_dropdown_item_1line,
                students
        );

        ArrayAdapter<Person> personsAdapter = new ArrayAdapter<Person>(
                this,
                android.R.layout.simple_list_item_1,
                persons
        );

        familyList.setAdapter(personsAdapter);
        studentsSpinner.setAdapter(studentsAdapter);

        familyList.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int position, long l) {
                Toast.makeText(MainActivity.this, persons.get(position).getInfo(), Toast.LENGTH_SHORT).show();
            }
        });

        studentsSpinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int position, long l) {
                Toast.makeText(MainActivity.this, students.get(position), Toast.LENGTH_SHORT);
            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {

            }
        });
    }
}
package bg.tu_sofia.fpmi.jatos.domashno31;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Bundle;
import android.widget.TextView;

import java.util.LinkedList;
import java.util.List;

public class MainActivity extends AppCompatActivity {

    TextView input;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        List<String> items= new LinkedList<>();

        RecyclerView recycleView = findViewById(R.id.itemDisplay);
        recycleView.setLayoutManager(new LinearLayoutManager(this));
        ListA adapter = new ListA(items);
        recycleView.setAdapter(adapter);

        this.input = findViewById(R.id.itemInput);
        findViewById(R.id.button).setOnClickListener(view -> {
            String inputText = this.input.getText().toString();
            items.add(inputText);
            adapter.notifyItemInserted(items.size()-1);
        });
    }
}
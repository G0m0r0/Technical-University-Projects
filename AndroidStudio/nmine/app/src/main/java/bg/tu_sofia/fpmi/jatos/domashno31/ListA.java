package bg.tu_sofia.fpmi.jatos.domashno31;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;

public class ListA extends RecyclerView.Adapter<ListVH> {

    List<String> items;

    ListA(List<String> items){
        this.items = items;
    }
    @NonNull
    @Override
    public ListVH onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.item,parent,false);
        return new ListVH(view).linkAdpter(this);
    }
    @Override
    public void onBindViewHolder(@NonNull ListVH holder, int position) {
        holder.textView.setText(items.get(position));
    }
    @Override
    public int getItemCount() {
        return items.size();
    }
}

class ListVH extends RecyclerView.ViewHolder{

    TextView textView;
    private ListA adapter;

    public ListVH(@NonNull View itemView) {
        super(itemView);

        textView = itemView.findViewById(R.id.text);
        itemView.findViewById(R.id.deleteButton).setOnClickListener(view -> {
            adapter.items.remove(getAdapterPosition());
            adapter.notifyItemRemoved(getAdapterPosition());
        });
    }

    public ListVH linkAdpter(ListA adapter){
        this.adapter = adapter;
        return this;
    }
}


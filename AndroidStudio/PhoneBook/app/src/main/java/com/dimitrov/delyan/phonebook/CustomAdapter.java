package com.dimitrov.delyan.phonebook;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Build;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.widget.LinearLayout;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.RequiresApi;
import androidx.cardview.widget.CardView;
import androidx.recyclerview.widget.RecyclerView;

import java.util.ArrayList;

public class CustomAdapter extends RecyclerView.Adapter<CustomAdapter.MyViewHolder> {

    private Context context;
    private Activity activity;
    private ArrayList book_id, fName, lName, phoneNum;

    CustomAdapter(Activity activity, Context context, ArrayList book_id, ArrayList fName, ArrayList lName,
                  ArrayList phoneNum){
        this.activity = activity;
        this.context = context;
        this.book_id = book_id;
        this.fName = fName;
        this.lName = lName;
        this.phoneNum = phoneNum;
    }

    @NonNull
    @Override
    public MyViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        LayoutInflater inflater = LayoutInflater.from(context);
        View view = inflater.inflate(R.layout.my_row, parent, false);
        return new MyViewHolder(view);
    }

    @RequiresApi(api = Build.VERSION_CODES.M)
    @Override
    public void onBindViewHolder(@NonNull final MyViewHolder holder, final int position) {
        holder.book_id_txt.setText(String.valueOf(book_id.get(position)));
        holder.book_fName_txt.setText(String.valueOf(fName.get(position)));
        holder.book_lName_txt.setText(String.valueOf(lName.get(position)));
        holder.book_phone_txt.setText(String.valueOf(phoneNum.get(position)));

        holder.mainLayout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(context, UpdateActivity.class);
                intent.putExtra("id", String.valueOf(book_id.get(position)));
                intent.putExtra("fName", String.valueOf(fName.get(position)));
                intent.putExtra("lName", String.valueOf(lName.get(position)));
                intent.putExtra("phoneNum", String.valueOf(phoneNum.get(position)));
                activity.startActivityForResult(intent, 1);
            }
        });


    }

    @Override
    public int getItemCount() {
        return book_id.size();
    }

    class MyViewHolder extends RecyclerView.ViewHolder {

        TextView book_id_txt, book_fName_txt, book_lName_txt, book_phone_txt;
        LinearLayout mainLayout;

        MyViewHolder(@NonNull View itemView) {
            super(itemView);
            book_id_txt = itemView.findViewById(R.id.book_id_txt);
            book_fName_txt = itemView.findViewById(R.id.book_title_txt);
            book_lName_txt = itemView.findViewById(R.id.book_author_txt);
            book_phone_txt = itemView.findViewById(R.id.book_pages_txt);
            mainLayout = itemView.findViewById(R.id.mainLayout);

            Animation translate_anim = AnimationUtils.loadAnimation(context, R.anim.translate_anim);
            mainLayout.setAnimation(translate_anim);
        }

    }

}

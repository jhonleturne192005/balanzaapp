package com.example.apppeso

import android.content.Context
import android.widget.Toast
import retrofit2.Retrofit

class ToastMessage
{
    public fun toast(context:Context,message:String)
    {
        Toast.makeText(context, message, Toast.LENGTH_SHORT).show()
    }
}
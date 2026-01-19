package com.example.apppeso

import okhttp3.Cookie
import okhttp3.CookieJar
import okhttp3.HttpUrl
import okhttp3.OkHttpClient
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

class SessionCookieJar : CookieJar {
    private val cookieStore = mutableMapOf<String, MutableList<Cookie>>() // Almacén de cookies

    override fun saveFromResponse(url: HttpUrl, cookies: List<Cookie>) {
        // Guarda las cookies enviadas por el servidor
        cookieStore[url.host] = cookies.toMutableList()
    }

    override fun loadForRequest(url: HttpUrl): List<Cookie> {
        // Devuelve las cookies asociadas al dominio
        return cookieStore[url.host] ?: mutableListOf()
    }
}

val okHttpClient = OkHttpClient.Builder()
    .cookieJar(SessionCookieJar())  // Usamos el CookieJar personalizado para una sola cookie
    .build()


class RetrofitService {
    fun getRetrofit(url:String): Retrofit
    {
        val retrofit= Retrofit
            .Builder()
            .baseUrl(url)
            .client(okHttpClient)
            .addConverterFactory(GsonConverterFactory.create())
            .build()
        return retrofit;
    }
}
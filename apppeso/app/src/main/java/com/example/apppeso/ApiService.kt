package com.example.apppeso

import com.example.apppeso.data_response.DataR
import com.example.apppeso.data_response.pesos_model
import retrofit2.Response
import retrofit2.http.Body
import retrofit2.http.Field
import retrofit2.http.FormUrlEncoded
import retrofit2.http.GET
import retrofit2.http.POST

interface ApiService {

    //@FormUrlEncoded
    @POST("/insert_data")
    suspend fun InsertData(@Body pesos_m: pesos_model): Response<DataR>;

    //api c
    @GET("/aum")
    suspend fun aum(): Response<DataR>;

    @GET("/des")
    suspend fun des(): Response<DataR>;

    @GET("/tara")
    suspend fun tara(): Response<DataR>;
}
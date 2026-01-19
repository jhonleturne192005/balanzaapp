from flask import Flask, jsonify, request
from db import engine,Peso
from sqlalchemy.orm import sessionmaker

app=Flask(__name__)

Session = sessionmaker(bind=engine)
session = Session()

@app.route('/insert_data', methods=['POST'])
def insert_data():
    try:
        data = request.json
        peso_bruto = data['peso_bruto']
        peso_actual = data['peso_actual']
        tara = data['tara']

        nuevo_peso = Peso(
            peso_bruto=peso_bruto,
            peso_actual=peso_actual,
            tara=tara
        )
        session.add(nuevo_peso)
        session.commit()
        return jsonify({"message": "Data inserted successfully"}), 200
    except Exception as e:
        return jsonify({"error": str(e)}), 400

if __name__=="__main__":
    app.run(debug=True,port=5000,host='0.0.0.0')
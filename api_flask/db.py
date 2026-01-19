from sqlalchemy import create_engine, Column, Integer, Float, DateTime
from sqlalchemy.orm import sessionmaker
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy_utils import database_exists, create_database
from datetime import datetime
import json

with open('config.json') as config_file:
    config = json.load(config_file) 

db_config = config['postgres']

def engine_ref():
    DATABASE_URL = f"postgresql+psycopg2://{db_config['user']}:{db_config['password']}@{db_config['host']}:{db_config['port']}/{db_config['database']}"
    if not database_exists(DATABASE_URL):
        create_database(DATABASE_URL)
    engine = create_engine(DATABASE_URL, echo=True)
    return engine

engine=engine_ref()
Base = declarative_base()

class Peso(Base):
    __tablename__ = "pesos"

    id_peso = Column(Integer, primary_key=True, autoincrement=True)
    peso_bruto = Column(Float, nullable=False)
    peso_actual = Column(Float, nullable=False)
    tara = Column(Float, nullable=False)
    fecha_actual = Column(DateTime, default=datetime.now)

    def __repr__(self) -> str:
        return f"Peso(id_peso={self.id_peso!r}, peso_bruto={self.peso_bruto!r}, peso_actual={self.peso_actual!r}, tara={self.tara!r}, fecha_actual={self.fecha_actual!r})"

Base.metadata.create_all(engine)
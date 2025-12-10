import streamlit as st
import pandas as pd

st.title("My First Streamlit App")
st.write("Hello Yashvi! This is your first Streamlit app.")

# Create a simple DataFrame
data = {
    'Name': ['Alice', 'Bob', 'Charlie'],
    'Age': [24, 30, 22],
    'City': ['New York', 'Los Angeles', 'Chicago']
}

df = pd.read_csv(r'\HeartDisease_Project\cardio_train.csv', sep=';')
st.write("Here is a simple DataFrame:")
st.dataframe(df)
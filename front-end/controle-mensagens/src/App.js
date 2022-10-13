import logo from './logo.svg';
import './App.css';


import React, { useState, useEffect } from 'react'
import api from './services/api';

export default function App() {
  const [mensagens, setMen] = useState([]);

  useEffect(() => {
    api.post('List').then(({ data }) => {
      setMen(data)
    })
  })

  return (
    <div className="App">
      <header className="App-header">
        {mensagens.map(item =>
        (
          <div key={item.id}> {item.id} - {item.titulo}</div>
        )
        )}
      </header>
    </div>

  );
}
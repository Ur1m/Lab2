import React from 'react';
import logo from './logo.svg';
import './App.css';
import CategoryList from './Category/CategoryList';
import CategoryForm from './Category/CategoryForm';

function App() {
  return (
    <div className="App">
      <CategoryList/>
      <CategoryForm/>
    </div>
  );
}

export default App;

import logo from "./logo.svg";
import "./App.css";
import HomePage from "./components/Home";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Contact from "./components/Contact";

function App() {
  return (
    // <div className="App">
    //   <HomePage content={"test content home"}></HomePage>
    // </div>
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/contact" element={<Contact />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;

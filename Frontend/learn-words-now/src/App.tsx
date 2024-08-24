import "./App.scss";
import { HomePage } from "./components/homePage/homePage";
import { Header } from "./components/header/header";
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";

function App() {
  return (
    <div className="app">
      <BrowserRouter>
        <Header />
        <Routes>
          <Route path="homePage" element={<HomePage />} />
          <Route path="*" element={<Navigate to="/homePage" replace />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;

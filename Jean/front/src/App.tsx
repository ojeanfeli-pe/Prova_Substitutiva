import React from 'react';
import './App.css';

function App() {
  return (
    <div>
     <BrowserRouter>
        <nav>
          <ul>
            <li>
              <Link to={"/"}>Home</Link>
            </li>
            <li>
              <Link to={"/pages/aluno/cadastrar"}>
               Cadastrar Aluno{" "}
              </Link>
            </li>
            <li>
              <Link to={"/pages/imc/cadastrar"}>
                Cadastrar IMC{" "}
              </Link>
            </li>
            <li>
              <Link to={"/pages/imc/listar"}>
              Listar IMCs	{" "}
              </Link>
            </li>
            <li>
              <Link to={"/pages/imc/listarporaluno"}>
              Listar IMCs por aluno{" "}
              </Link>
            </li>
          </ul>
        </nav>
        <Routes>
          <Route path="/" element={<ProdutoListar />} />
          <Route
            path="/pages/produto/listar"
            element={<ProdutoListar />}
          />
          <Route
            path="/pages/produto/cadastrar"
            element={<ProdutoCadastrar />}
          />
          <Route
            path="/pages/cep/consultar"
            element={<CepConsultar />}
          />
          <Route
            path="/pages/produto/alterar/:id"
            element={<ProdutoAlterar />}
          />
        </Routes>
        <footer>
          <p>Desenvolvido por Diogo Steinke Deconto</p>
        </footer>
      </BrowserRouter>
    </div>
  );
}

export default App;
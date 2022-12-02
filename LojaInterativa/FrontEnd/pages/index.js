import CardFabricante from "../Components/CardFabricante";
import CardProduto from "../Components/CardProduto";
import axios from "axios";
import { useEffect, useState } from "react";

export default function Home() {
  const [produtos, setProdutos] = useState();
  useEffect(() => {
    async function getProducts() {
      await axios("https://localhost:7058/produto/")
        .then((res) => setProdutos(res.data))
        .catch((err) => console.log(err));
    }
    getProducts();
  }, []);

  async function handleDelete(id) {
    await axios({
      method: "DELETE",
      url: `https://localhost:7058/delete/${id}`,
    })
      .then(() => location.reload())
      .catch((err) => console.log(err));
  }

  console.log(produtos);
  return (
    <div>
      <div className="my-20 flex flex-raw justify-evenly">
        <CardFabricante />
        <CardProduto />
      </div>
      <div className="">
        <div className="">
          <div className="flex justify-evenly">
            <div>ID</div>
            <div>Nome Produto</div>
            <div>Fabricante</div>
            <div>Categoria</div>
            <div>Preço</div>
            <div>Editar</div>
            <div>Deletar</div>
          </div>
          <div>
            {produtos?.map((produto) => (
              <div key={produto.idProduto} className="flex justify-evenly p-9">
                <div>{produto.idProduto}</div>
                <div>{produto.descricaoProduto}</div>
                <div>{produto.nomeFabricante}</div>
                <div>{produto.nomeCategoria}</div>
                <div>{produto.precoProduto}</div>
                <div>Editar</div>
                <div onClick={() => handleDelete(produto.idProduto)}>
                  <button className="bg-red-600">Deletar</button>
                </div>
              </div>
            ))}
          </div>
        </div>
      </div>
    </div>
  );
}

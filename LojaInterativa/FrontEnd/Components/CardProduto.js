import axios from "axios";
import { useEffect, useState } from "react";
import { useForm } from "react-hook-form";

export default function CardProduto() {
  const [fabricantes, setFabricantes] = useState([{}]);
  const {
    register,
    handleSubmit,
    watch,
    formState: { errors },
  } = useForm();
  const onSubmit = (data) => {
    axios("https://localhost:7058/produto/", {
      method: "POST",
      data: data,
    })
      .then(() => location.reload())
      .catch((err) => console.log(err));
  };

  useEffect(() => {
    axios("https://localhost:7058/fabricante/").then((res) => {
      setFabricantes(res.data);
    });
  }, []);

  const id = watch("idFabricante");

  const fabricanteSelecionado = fabricantes.find((item) => item.idFabricante == id);

  // console.log(fabricanteSelecionado?.categorias);
  // console.log({ id });

  return (
    <div className="flex flex-col">
      <h1 className="py-2">Produto</h1>
      <form className="flex flex-col" onSubmit={handleSubmit(onSubmit)}>
        <label className="flex flex-col">
          Nome do produto
          <input
            {...register("descricaoProduto", { required: true })}
            type="text"
            className="shadow appearance-none border rounded w-80 py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          />
        </label>
        <label className="flex flex-col">Fabricante</label>
        <select {...register("idFabricante")}>
          <option hidden>Selecione</option>
          {fabricantes.map((item, index) => (
            <option key={index} value={item.idFabricante}>
              {item.nomeFabricante}
            </option>
          ))}
        </select>
        <label className="flex flex-col">
          Categoria
          <select
            {...register("categoriaProduto", { required: true })}
            disabled={!fabricanteSelecionado?.categorias?.length}
          >
            {fabricanteSelecionado?.categorias?.length > 0 && (
              <>
                {fabricanteSelecionado.categorias.map((item) => (
                  <option key={item} value={item}>
                    {item}
                  </option>
                ))}
              </>
            )}
          </select>
        </label>
        <label className="flex flex-col">
          Preço
          <input
            {...register("precoProduto", { required: true })}
            type="number"
            step="any"
            className="shadow appearance-none border rounded w-80 py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          />
        </label>
        <button className="bg-blue-900 rounded-md p-1 my-2 text-white">
          Adicionar produto
        </button>
      </form>
    </div>
  );
}

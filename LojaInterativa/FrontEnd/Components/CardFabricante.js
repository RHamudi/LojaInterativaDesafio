import { useForm } from "react-hook-form";
import axios from "axios";

export default function CardFabricante() {
  const {
    register,
    handleSubmit,
    watch,
    formState: { errors },
  } = useForm();

  const onSubmit = (data) => {
    axios("https://localhost:7058/fabricante/", {
      method: "POST",
      data: data,
    })
      .then((res) => location.reload())
      .catch((err) => console.log(err));
  };

  return (
    <div className="flex flex-col">
      <h1 className="py-2">Fabricante e Categoria</h1>
      <form onSubmit={handleSubmit(onSubmit)}>
        <div>
          <label className="flex flex-col">
            Fabricante
            <input
              {...register("nomeFabricante", { required: true })}
              type="text"
              className="shadow appearance-none border rounded w-80 py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            />
          </label>
        </div>
        <div>
          <label className="flex flex-col gap-5">
            Categorias
            <input
              {...register("categoria1", { required: true })}
              type="text"
              className="shadow appearance-none border rounded w-80 py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            />
            <input
              {...register("categoria2", { required: true })}
              type="text"
              className="shadow appearance-none border rounded w-80 py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            />
            <input
              {...register("categoria3", { required: true })}
              type="text"
              className="shadow appearance-none border rounded w-80 py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            />
          </label>
        </div>
        <button type="submit" className="bg-blue-900 rounded-md p-1 my-2 text-white">
          Adicionar Categoria
        </button>
      </form>
    </div>
  );
}

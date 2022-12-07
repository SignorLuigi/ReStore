import { useState, useEffect } from "react";
import agent from "../../app/api/agent";
import { Product } from "../../models/product";
import ProductList from "./ProductList";

export default function Catalog() {
  const [products, setProducts] = useState<Product[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    agent.Catalog.list()
      .then(response => setProducts(response))
      .catch(error => console.log(error.response))
      .finally(() => setLoading(false));
  }, [])

  if (loading) return <h3>Loading...</h3>
  if (!products) return <h3>Product not found</h3>

  return (
    <>
      <ProductList products={products} />
    </>
  )
}
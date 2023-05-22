import "./../../Css/bootstrap.css";
import "./../Products/Products.css";

export const ProductsTable = () => {
  return (
    <div class="container">
      <table class="table table-hover">
        <thead class="table-dark">
          <tr>
            <th scope="col">Type</th>
            <th scope="col">Column heading</th>
            <th scope="col">Column heading</th>
            <th scope="col">Column heading</th>
          </tr>
        </thead>
        <tbody>
          <tr class="table-secondary">
            <th scope="row">Secondary</th>
            <td>Column content</td>
            <td>Column content</td>
            <td>Column content</td>
          </tr>

          <tr class="table-secondary">
            <th scope="row">Secondary</th>
            <td>Column content</td>
            <td>Column content</td>
            <td>Column content</td>
          </tr>

          <tr class="table-secondary">
            <th scope="row">Secondary</th>
            <td>Column content</td>
            <td>Column content</td>
            <td>Column content</td>
          </tr>
        </tbody>
      </table>
    </div>
  );
};

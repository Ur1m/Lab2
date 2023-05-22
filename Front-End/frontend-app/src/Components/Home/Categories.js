import "./../../Css/bootstrap.css";
import "../Home/home.css";

export const Categories = () => {
  return (
    <div>
      <div className="col p-4 w-100 categories">
        <h2 className="text-center">MOST POPULAR CATEGORIES</h2>
        <div className="row">
          <div className="col Back-1"></div>
          <div className="col Back-2"></div>
          <div className="col Back-3"></div>
        </div>
        <div className="row">
          <div className="col titull">
            <h4>Bussines</h4>
          </div>
          <div className="col titulli1">
            <h4>Coding</h4>
          </div>
          <div className="col titull">
            <h4>Software Engineer</h4>
          </div>
        </div>
      </div>
    </div>
  );
};

import React, { useState } from "react";

export const Lab12_Program3 = () => {
  const [input, setInput] = useState("");

  const handleButtonClick = (value) => {
    setInput(input + value);
  };

  const handleClear = () => {
    setInput("");
  };

  const handleCalculate = () => {
    try {
      setInput(eval(input));
    } catch (error) {
      setInput("Error");
    }
  };

  return (
    <div className="calculator" style={{ width: "80vw" }}>
      <div className="display">{input || "0"}</div>
      <div className="buttons">
        <div className="row">
          <button
            className="col-3 btn btn-outline-primary"
            onClick={() => handleButtonClick("7")}
          >
            7
          </button>
          <button
            className="col-3 btn btn-outline-primary"
            onClick={() => handleButtonClick("8")}
          >
            8
          </button>
          <button
            className="col-3 btn btn-outline-primary"
            onClick={() => handleButtonClick("9")}
          >
            9
          </button>
          <button
            className="col-3 btn btn-outline-primary"
            onClick={() => handleButtonClick("+")}
          >
            +
          </button>
        </div>
        <div className="row">
          <button
            className="col-3 btn btn-outline-primary"
            onClick={() => handleButtonClick("4")}
          >
            4
          </button>
          <button
            className="col-3 btn btn-outline-primary"
            onClick={() => handleButtonClick("5")}
          >
            5
          </button>
          <button
            className="col-3 btn btn-outline-primary"
            onClick={() => handleButtonClick("6")}
          >
            6
          </button>
          <button
            className="col-3 btn btn-outline-primary"
            onClick={() => handleButtonClick("-")}
          >
            -
          </button>
        </div>
        <div className="row">
          <button
            className="col-3 btn btn-outline-primary"
            onClick={() => handleButtonClick("1")}
          >
            1
          </button>
          <button
            className="col-3 btn btn-outline-primary"
            onClick={() => handleButtonClick("2")}
          >
            2
          </button>
          <button
            className="col-3 btn btn-outline-primary"
            onClick={() => handleButtonClick("3")}
          >
            3
          </button>
          <button
            className="col-3 btn btn-outline-primary"
            onClick={() => handleButtonClick("*")}
          >
            *
          </button>
        </div>
        <div className="row">
          <button
            className="col-3 btn btn-outline-primary"
            onClick={() => handleButtonClick("0")}
          >
            0
          </button>
          <button
            className="col-3 btn btn-outline-primary"
            onClick={handleClear}
          >
            C
          </button>
          <button
            className="col-3 btn btn-outline-primary"
            onClick={handleCalculate}
          >
            =
          </button>
          <button
            className="col-3 btn btn-outline-primary"
            onClick={() => handleButtonClick("/")}
          >
            /
          </button>
        </div>
      </div>
    </div>
  );
};

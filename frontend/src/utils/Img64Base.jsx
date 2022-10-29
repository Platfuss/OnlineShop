import React from "react";

const Img64Base = ({ src, alt = "", ...props }) => {
	return <img src={`data:image/jpg;base64,${src}`} alt={alt} {...props} />;
};

export default Img64Base;

import React from "react";
import { Flex, Text, Image } from "@chakra-ui/react";

import noresult from "../../assets/images/noresult.svg";

const NoResult = ({ count }) => {
  return (
    <>
      {count === 0 && (
        <Flex
          justifyContent='center'
          alignItems='center'
          flexDir='column'
          marginTop='5'
          marginBottom='5'
        >
          <Image src={noresult} />
          <Text fontSize='xl' marginTop='3'>
            No Result Found.
          </Text>
        </Flex>
      )}
    </>
  );
};

export default NoResult;

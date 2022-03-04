import React from "react";
import { Box, Image, Flex, Text } from "@chakra-ui/react";
// import { StarIcon } from "@chakra-ui/icons";
// import { Link } from "react-router-dom";
import { FaBed, FaBath } from "react-icons/fa";
import { BsGridFill } from "react-icons/bs";
import { GoVerified } from "react-icons/go";

import millify from "millify";
import { Link } from "react-router-dom";

const Property = ({
  property: { id, title, image, area, baths, price, rooms },
}) => {
  const imgUrl = `data:image/png;base64, ${image}`;
  return (
    <>
      <Flex
        flexWrap='wrap'
        w='420px'
        p='5'
        paddingTop='0px'
        justifyContent='flex-start'
      >
        <Box>
          <Link to={`/property/${id}`}>
            <Image src={imgUrl} w={400} h={260} />
          </Link>
        </Box>
        <Box w='full'>
          <Flex
            paddingTop='2'
            alignItems='center'
            justifyContent='space-between'
          >
            <Text fontWeight='bold' fontSize='lg'>
              {title.length > 30 ? title.substring(0, 30) + "..." : title}
            </Text>
            <Flex alignItems='center'>
              <Box paddingRight='1' color='green.400'>
                <GoVerified />
              </Box>
              <Text fontWeight='bold' fontSize='lg'>
                EGP {millify(price, { decimalSeparator: "." })}
              </Text>
            </Flex>
          </Flex>
          <Flex
            alignItems='center'
            p='1'
            justifyContent='space-between'
            w='250px'
            color='blue.400'
          >
            {rooms || 0}
            <FaBed /> | {baths || 0} <FaBath /> | {millify(area)} sqft{" "}
            <BsGridFill />
          </Flex>
        </Box>
      </Flex>
    </>
  );
};

export default Property;

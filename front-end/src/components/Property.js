import React from "react";
import { Box, Image, Flex, Text, Stack, Badge, Button } from "@chakra-ui/react";
// import { StarIcon } from "@chakra-ui/icons";
// import { Link } from "react-router-dom";
import { FaBed, FaBath,FaMapMarkerAlt } from "react-icons/fa";
import { BsGridFill } from "react-icons/bs";
import { GoVerified } from "react-icons/go";
import {FcLike} from "react-icons/fc"
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { useColorModeValue } from "@chakra-ui/react";
// import { faHeart as farHeart } from '@fortawesome/free-regular-svg-icons';


import millify from "millify";
import { Link } from "react-router-dom";

const Property = ({
  property: { id, title, image, area, baths, price, rooms,status,address },
}) => {
  const imgUrl = `data:image/png;base64, ${image}`;
  return (
    <Flex
    flexWrap="wrap"
    w="420px"
    p="5"
    paddingTop="0px"
    justifyContent="flex-start"
  >
    <Box as='cite'
      w={400}
      rounded={10}
      bg={"gray.200"}
      overflow={"hidden"}
      boxShadow={"sm"}
    >
      <Link to={`/property/${id}`}>
        <Image src={imgUrl} w={400} h={260} />
      </Link>

      <Box w="full" p={5}>
        <Flex
          paddingTop="2"
          alignItems="center"
          justifyContent="space-between"
        >
        <Stack isInline align='baseline'>
            <Badge
              variant={"solid"}
              bg={"teal"}
              rounded={"full"}
              px={4}
            >
              {status}
            </Badge>
          <Text as='cite' fontWeight="bold" fontSize="lg" textTransform={"uppercase"} color={"gray.500"}>
            {title.length > 30 ? title.substring(0, 30) + "..." : title}
          </Text>
          <Box paddingRight="1" color="green.400">
              <GoVerified />
            </Box>              
            </Stack>
          <Text color={useColorModeValue("gray.700","gray.700" )} fontWeight="bold" fontSize="lg">
            {millify(price, { decimalSeparator: "." })} EGP
            </Text>
        
        </Flex>
        <Stack isInline align='baseline' color={useColorModeValue("gray.700","gray.700" )} >
        <FaMapMarkerAlt/>  <Text 
        fontWeight={'semibold'} fontSize='xl' my={2}>
        {address.state}-{address.city}-{address.street}  
          </Text></Stack>
        <Flex
          alignItems="center"
          p="1"
          justifyContent="space-between"
          w="250px"
          color="blue.400"
        >
          {rooms || 0}
          <FaBed /> | {baths || 0} <FaBath /> | {millify(area)} M2 {" "}
          <BsGridFill />
        </Flex>
        
        <Flex alignItems='center' justifyContent={'space-between'}  > 
        <Link to={`/property/${id}`}>
            <Button as='cite'  color = 'white' bg={"teal"} size='md' mt={3} boxShadow='sm' _hover={{boxShadow: 'md'}} _active={{boxShadow: 'lg'}} >
            More Details
            </Button>
            </Link>
        
           <Box>
            {/* <FontAwesomeIcon icon="fa-regular fa-heart" /> */}
            <FontAwesomeIcon icon="fa-thin fa-heart" />
            </Box>

        </Flex>
      </Box>
    </Box>
  </Flex>
   );
};

export default Property;

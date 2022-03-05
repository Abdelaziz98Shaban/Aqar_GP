import React from "react";
import { Link } from "react-router-dom";

import { Flex, Box, Text, Button, Image } from "@chakra-ui/react";
import { useColorModeValue } from "@chakra-ui/react";
const Banner = ({
  purpose,
  title1,
  title2,
  desc1,
  desc2,
  buttonText,
  linkName,
  imageUrl,
}) => {
  return (
    <Flex  flexWrap="wrap" justifyContent="center" alignItems="center" m="10">
      <Image src={imageUrl} w={500} h={300} alt="banner" />
      <Box p="5">
        <Text color="gray.500" fontSize="sm" fontWeight="medium">
          {purpose}
        </Text>
        <Text fontSize="3xl" fontWeight="bold">
          {title1}
          <br />
          {title2}
        </Text>
        <Text fontSize="lg" paddingTop="3" paddingBottom="3"color={useColorModeValue("gray.900","white")}>
          {desc1}
          <br />
          {desc2}
        </Text>
        <Button fontSize="xl">
          <Link to={linkName}>{buttonText}</Link>
        </Button>
      </Box>
    </Flex>
  );
};

export default Banner;
